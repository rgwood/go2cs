// Copyright 2009 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// Package image implements a basic 2-D image library.
//
// The fundamental interface is called Image. An Image contains colors, which
// are described in the image/color package.
//
// Values of the Image interface are created either by calling functions such
// as NewRGBA and NewPaletted, or by calling Decode on an io.Reader containing
// image data in a format such as GIF, JPEG or PNG. Decoding any particular
// image format requires the prior registration of a decoder function.
// Registration is typically automatic as a side effect of initializing that
// format's package so that, to decode a PNG image, it suffices to have
//    import _ "image/png"
// in a program's main package. The _ means to import a package purely for its
// initialization side effects.
//
// See "The Go image package" for more details:
// https://golang.org/doc/articles/image_package.html
// package image -- go2cs converted at 2020 October 09 06:05:42 UTC
// import "image" ==> using image = go.image_package
// Original source: C:\Go\src\image\image.go
using color = go.image.color_package;
using static go.builtin;

namespace go
{
    public static partial class image_package
    {
        // Config holds an image's color model and dimensions.
        public partial struct Config
        {
            public color.Model ColorModel;
            public long Width;
            public long Height;
        }

        // Image is a finite rectangular grid of color.Color values taken from a color
        // model.
        public partial interface Image
        {
            color.Color ColorModel(); // Bounds returns the domain for which At can return non-zero color.
// The bounds do not necessarily contain the point (0, 0).
            color.Color Bounds(); // At returns the color of the pixel at (x, y).
// At(Bounds().Min.X, Bounds().Min.Y) returns the upper-left pixel of the grid.
// At(Bounds().Max.X-1, Bounds().Max.Y-1) returns the lower-right one.
            color.Color At(long x, long y);
        }

        // PalettedImage is an image whose colors may come from a limited palette.
        // If m is a PalettedImage and m.ColorModel() returns a color.Palette p,
        // then m.At(x, y) should be equivalent to p[m.ColorIndexAt(x, y)]. If m's
        // color model is not a color.Palette, then ColorIndexAt's behavior is
        // undefined.
        public partial interface PalettedImage : Image
        {
            byte ColorIndexAt(long x, long y);
        }

        // pixelBufferLength returns the length of the []uint8 typed Pix slice field
        // for the NewXxx functions. Conceptually, this is just (bpp * width * height),
        // but this function panics if at least one of those is negative or if the
        // computation would overflow the int type.
        //
        // This panics instead of returning an error because of backwards
        // compatibility. The NewXxx functions do not return an error.
        private static long pixelBufferLength(long bytesPerPixel, Rectangle r, @string imageTypeName) => func((_, panic, __) =>
        {
            var totalLength = mul3NonNeg(bytesPerPixel, r.Dx(), r.Dy());
            if (totalLength < 0L)
            {
                panic("image: New" + imageTypeName + " Rectangle has huge or negative dimensions");
            }

            return totalLength;

        });

        // RGBA is an in-memory image whose At method returns color.RGBA values.
        public partial struct RGBA
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<RGBA> _addr_p)
        {
            ref RGBA p = ref _addr_p.val;

            return color.RGBAModel;
        }

        private static Rectangle Bounds(this ptr<RGBA> _addr_p)
        {
            ref RGBA p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<RGBA> _addr_p, long x, long y)
        {
            ref RGBA p = ref _addr_p.val;

            return p.RGBAAt(x, y);
        }

        private static color.RGBA RGBAAt(this ptr<RGBA> _addr_p, long x, long y)
        {
            ref RGBA p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.RGBA();
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            return new color.RGBA(s[0],s[1],s[2],s[3]);

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<RGBA> _addr_p, long x, long y)
        {
            ref RGBA p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 4L;
        }

        private static void Set(this ptr<RGBA> _addr_p, long x, long y, color.Color c)
        {
            ref RGBA p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            color.RGBA c1 = color.RGBAModel.Convert(c)._<color.RGBA>();
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = c1.R;
            s[1L] = c1.G;
            s[2L] = c1.B;
            s[3L] = c1.A;

        }

        private static void SetRGBA(this ptr<RGBA> _addr_p, long x, long y, color.RGBA c)
        {
            ref RGBA p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = c.R;
            s[1L] = c.G;
            s[2L] = c.B;
            s[3L] = c.A;

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<RGBA> _addr_p, Rectangle r)
        {
            ref RGBA p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new RGBA());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new RGBA(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<RGBA> _addr_p)
        {
            ref RGBA p = ref _addr_p.val;

            if (p.Rect.Empty())
            {
                return true;
            }

            long i0 = 3L;
            var i1 = p.Rect.Dx() * 4L;
            for (var y = p.Rect.Min.Y; y < p.Rect.Max.Y; y++)
            {
                {
                    var i = i0;

                    while (i < i1)
                    {
                        if (p.Pix[i] != 0xffUL)
                        {
                            return false;
                        i += 4L;
                        }

                    }

                }
                i0 += p.Stride;
                i1 += p.Stride;

            }

            return true;

        }

        // NewRGBA returns a new RGBA image with the given bounds.
        public static ptr<RGBA> NewRGBA(Rectangle r)
        {
            return addr(new RGBA(Pix:make([]uint8,pixelBufferLength(4,r,"RGBA")),Stride:4*r.Dx(),Rect:r,));
        }

        // RGBA64 is an in-memory image whose At method returns color.RGBA64 values.
        public partial struct RGBA64
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<RGBA64> _addr_p)
        {
            ref RGBA64 p = ref _addr_p.val;

            return color.RGBA64Model;
        }

        private static Rectangle Bounds(this ptr<RGBA64> _addr_p)
        {
            ref RGBA64 p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<RGBA64> _addr_p, long x, long y)
        {
            ref RGBA64 p = ref _addr_p.val;

            return p.RGBA64At(x, y);
        }

        private static color.RGBA64 RGBA64At(this ptr<RGBA64> _addr_p, long x, long y)
        {
            ref RGBA64 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.RGBA64();
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 8L, i + 8L); // Small cap improves performance, see https://golang.org/issue/27857
            return new color.RGBA64(uint16(s[0])<<8|uint16(s[1]),uint16(s[2])<<8|uint16(s[3]),uint16(s[4])<<8|uint16(s[5]),uint16(s[6])<<8|uint16(s[7]),);

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<RGBA64> _addr_p, long x, long y)
        {
            ref RGBA64 p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 8L;
        }

        private static void Set(this ptr<RGBA64> _addr_p, long x, long y, color.Color c)
        {
            ref RGBA64 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            color.RGBA64 c1 = color.RGBA64Model.Convert(c)._<color.RGBA64>();
            var s = p.Pix.slice(i, i + 8L, i + 8L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = uint8(c1.R >> (int)(8L));
            s[1L] = uint8(c1.R);
            s[2L] = uint8(c1.G >> (int)(8L));
            s[3L] = uint8(c1.G);
            s[4L] = uint8(c1.B >> (int)(8L));
            s[5L] = uint8(c1.B);
            s[6L] = uint8(c1.A >> (int)(8L));
            s[7L] = uint8(c1.A);

        }

        private static void SetRGBA64(this ptr<RGBA64> _addr_p, long x, long y, color.RGBA64 c)
        {
            ref RGBA64 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 8L, i + 8L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = uint8(c.R >> (int)(8L));
            s[1L] = uint8(c.R);
            s[2L] = uint8(c.G >> (int)(8L));
            s[3L] = uint8(c.G);
            s[4L] = uint8(c.B >> (int)(8L));
            s[5L] = uint8(c.B);
            s[6L] = uint8(c.A >> (int)(8L));
            s[7L] = uint8(c.A);

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<RGBA64> _addr_p, Rectangle r)
        {
            ref RGBA64 p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new RGBA64());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new RGBA64(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<RGBA64> _addr_p)
        {
            ref RGBA64 p = ref _addr_p.val;

            if (p.Rect.Empty())
            {
                return true;
            }

            long i0 = 6L;
            var i1 = p.Rect.Dx() * 8L;
            for (var y = p.Rect.Min.Y; y < p.Rect.Max.Y; y++)
            {
                {
                    var i = i0;

                    while (i < i1)
                    {
                        if (p.Pix[i + 0L] != 0xffUL || p.Pix[i + 1L] != 0xffUL)
                        {
                            return false;
                        i += 8L;
                        }

                    }

                }
                i0 += p.Stride;
                i1 += p.Stride;

            }

            return true;

        }

        // NewRGBA64 returns a new RGBA64 image with the given bounds.
        public static ptr<RGBA64> NewRGBA64(Rectangle r)
        {
            return addr(new RGBA64(Pix:make([]uint8,pixelBufferLength(8,r,"RGBA64")),Stride:8*r.Dx(),Rect:r,));
        }

        // NRGBA is an in-memory image whose At method returns color.NRGBA values.
        public partial struct NRGBA
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<NRGBA> _addr_p)
        {
            ref NRGBA p = ref _addr_p.val;

            return color.NRGBAModel;
        }

        private static Rectangle Bounds(this ptr<NRGBA> _addr_p)
        {
            ref NRGBA p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<NRGBA> _addr_p, long x, long y)
        {
            ref NRGBA p = ref _addr_p.val;

            return p.NRGBAAt(x, y);
        }

        private static color.NRGBA NRGBAAt(this ptr<NRGBA> _addr_p, long x, long y)
        {
            ref NRGBA p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.NRGBA();
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            return new color.NRGBA(s[0],s[1],s[2],s[3]);

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<NRGBA> _addr_p, long x, long y)
        {
            ref NRGBA p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 4L;
        }

        private static void Set(this ptr<NRGBA> _addr_p, long x, long y, color.Color c)
        {
            ref NRGBA p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            color.NRGBA c1 = color.NRGBAModel.Convert(c)._<color.NRGBA>();
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = c1.R;
            s[1L] = c1.G;
            s[2L] = c1.B;
            s[3L] = c1.A;

        }

        private static void SetNRGBA(this ptr<NRGBA> _addr_p, long x, long y, color.NRGBA c)
        {
            ref NRGBA p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = c.R;
            s[1L] = c.G;
            s[2L] = c.B;
            s[3L] = c.A;

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<NRGBA> _addr_p, Rectangle r)
        {
            ref NRGBA p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new NRGBA());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new NRGBA(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<NRGBA> _addr_p)
        {
            ref NRGBA p = ref _addr_p.val;

            if (p.Rect.Empty())
            {
                return true;
            }

            long i0 = 3L;
            var i1 = p.Rect.Dx() * 4L;
            for (var y = p.Rect.Min.Y; y < p.Rect.Max.Y; y++)
            {
                {
                    var i = i0;

                    while (i < i1)
                    {
                        if (p.Pix[i] != 0xffUL)
                        {
                            return false;
                        i += 4L;
                        }

                    }

                }
                i0 += p.Stride;
                i1 += p.Stride;

            }

            return true;

        }

        // NewNRGBA returns a new NRGBA image with the given bounds.
        public static ptr<NRGBA> NewNRGBA(Rectangle r)
        {
            return addr(new NRGBA(Pix:make([]uint8,pixelBufferLength(4,r,"NRGBA")),Stride:4*r.Dx(),Rect:r,));
        }

        // NRGBA64 is an in-memory image whose At method returns color.NRGBA64 values.
        public partial struct NRGBA64
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<NRGBA64> _addr_p)
        {
            ref NRGBA64 p = ref _addr_p.val;

            return color.NRGBA64Model;
        }

        private static Rectangle Bounds(this ptr<NRGBA64> _addr_p)
        {
            ref NRGBA64 p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<NRGBA64> _addr_p, long x, long y)
        {
            ref NRGBA64 p = ref _addr_p.val;

            return p.NRGBA64At(x, y);
        }

        private static color.NRGBA64 NRGBA64At(this ptr<NRGBA64> _addr_p, long x, long y)
        {
            ref NRGBA64 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.NRGBA64();
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 8L, i + 8L); // Small cap improves performance, see https://golang.org/issue/27857
            return new color.NRGBA64(uint16(s[0])<<8|uint16(s[1]),uint16(s[2])<<8|uint16(s[3]),uint16(s[4])<<8|uint16(s[5]),uint16(s[6])<<8|uint16(s[7]),);

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<NRGBA64> _addr_p, long x, long y)
        {
            ref NRGBA64 p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 8L;
        }

        private static void Set(this ptr<NRGBA64> _addr_p, long x, long y, color.Color c)
        {
            ref NRGBA64 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            color.NRGBA64 c1 = color.NRGBA64Model.Convert(c)._<color.NRGBA64>();
            var s = p.Pix.slice(i, i + 8L, i + 8L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = uint8(c1.R >> (int)(8L));
            s[1L] = uint8(c1.R);
            s[2L] = uint8(c1.G >> (int)(8L));
            s[3L] = uint8(c1.G);
            s[4L] = uint8(c1.B >> (int)(8L));
            s[5L] = uint8(c1.B);
            s[6L] = uint8(c1.A >> (int)(8L));
            s[7L] = uint8(c1.A);

        }

        private static void SetNRGBA64(this ptr<NRGBA64> _addr_p, long x, long y, color.NRGBA64 c)
        {
            ref NRGBA64 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 8L, i + 8L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = uint8(c.R >> (int)(8L));
            s[1L] = uint8(c.R);
            s[2L] = uint8(c.G >> (int)(8L));
            s[3L] = uint8(c.G);
            s[4L] = uint8(c.B >> (int)(8L));
            s[5L] = uint8(c.B);
            s[6L] = uint8(c.A >> (int)(8L));
            s[7L] = uint8(c.A);

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<NRGBA64> _addr_p, Rectangle r)
        {
            ref NRGBA64 p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new NRGBA64());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new NRGBA64(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<NRGBA64> _addr_p)
        {
            ref NRGBA64 p = ref _addr_p.val;

            if (p.Rect.Empty())
            {
                return true;
            }

            long i0 = 6L;
            var i1 = p.Rect.Dx() * 8L;
            for (var y = p.Rect.Min.Y; y < p.Rect.Max.Y; y++)
            {
                {
                    var i = i0;

                    while (i < i1)
                    {
                        if (p.Pix[i + 0L] != 0xffUL || p.Pix[i + 1L] != 0xffUL)
                        {
                            return false;
                        i += 8L;
                        }

                    }

                }
                i0 += p.Stride;
                i1 += p.Stride;

            }

            return true;

        }

        // NewNRGBA64 returns a new NRGBA64 image with the given bounds.
        public static ptr<NRGBA64> NewNRGBA64(Rectangle r)
        {
            return addr(new NRGBA64(Pix:make([]uint8,pixelBufferLength(8,r,"NRGBA64")),Stride:8*r.Dx(),Rect:r,));
        }

        // Alpha is an in-memory image whose At method returns color.Alpha values.
        public partial struct Alpha
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<Alpha> _addr_p)
        {
            ref Alpha p = ref _addr_p.val;

            return color.AlphaModel;
        }

        private static Rectangle Bounds(this ptr<Alpha> _addr_p)
        {
            ref Alpha p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<Alpha> _addr_p, long x, long y)
        {
            ref Alpha p = ref _addr_p.val;

            return p.AlphaAt(x, y);
        }

        private static color.Alpha AlphaAt(this ptr<Alpha> _addr_p, long x, long y)
        {
            ref Alpha p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.Alpha();
            }

            var i = p.PixOffset(x, y);
            return new color.Alpha(p.Pix[i]);

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<Alpha> _addr_p, long x, long y)
        {
            ref Alpha p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 1L;
        }

        private static void Set(this ptr<Alpha> _addr_p, long x, long y, color.Color c)
        {
            ref Alpha p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            p.Pix[i] = color.AlphaModel.Convert(c)._<color.Alpha>().A;

        }

        private static void SetAlpha(this ptr<Alpha> _addr_p, long x, long y, color.Alpha c)
        {
            ref Alpha p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            p.Pix[i] = c.A;

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<Alpha> _addr_p, Rectangle r)
        {
            ref Alpha p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new Alpha());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new Alpha(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<Alpha> _addr_p)
        {
            ref Alpha p = ref _addr_p.val;

            if (p.Rect.Empty())
            {
                return true;
            }

            long i0 = 0L;
            var i1 = p.Rect.Dx();
            for (var y = p.Rect.Min.Y; y < p.Rect.Max.Y; y++)
            {
                for (var i = i0; i < i1; i++)
                {
                    if (p.Pix[i] != 0xffUL)
                    {
                        return false;
                    }

                }

                i0 += p.Stride;
                i1 += p.Stride;

            }

            return true;

        }

        // NewAlpha returns a new Alpha image with the given bounds.
        public static ptr<Alpha> NewAlpha(Rectangle r)
        {
            return addr(new Alpha(Pix:make([]uint8,pixelBufferLength(1,r,"Alpha")),Stride:1*r.Dx(),Rect:r,));
        }

        // Alpha16 is an in-memory image whose At method returns color.Alpha16 values.
        public partial struct Alpha16
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<Alpha16> _addr_p)
        {
            ref Alpha16 p = ref _addr_p.val;

            return color.Alpha16Model;
        }

        private static Rectangle Bounds(this ptr<Alpha16> _addr_p)
        {
            ref Alpha16 p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<Alpha16> _addr_p, long x, long y)
        {
            ref Alpha16 p = ref _addr_p.val;

            return p.Alpha16At(x, y);
        }

        private static color.Alpha16 Alpha16At(this ptr<Alpha16> _addr_p, long x, long y)
        {
            ref Alpha16 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.Alpha16();
            }

            var i = p.PixOffset(x, y);
            return new color.Alpha16(uint16(p.Pix[i+0])<<8|uint16(p.Pix[i+1]));

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<Alpha16> _addr_p, long x, long y)
        {
            ref Alpha16 p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 2L;
        }

        private static void Set(this ptr<Alpha16> _addr_p, long x, long y, color.Color c)
        {
            ref Alpha16 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            color.Alpha16 c1 = color.Alpha16Model.Convert(c)._<color.Alpha16>();
            p.Pix[i + 0L] = uint8(c1.A >> (int)(8L));
            p.Pix[i + 1L] = uint8(c1.A);

        }

        private static void SetAlpha16(this ptr<Alpha16> _addr_p, long x, long y, color.Alpha16 c)
        {
            ref Alpha16 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            p.Pix[i + 0L] = uint8(c.A >> (int)(8L));
            p.Pix[i + 1L] = uint8(c.A);

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<Alpha16> _addr_p, Rectangle r)
        {
            ref Alpha16 p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new Alpha16());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new Alpha16(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<Alpha16> _addr_p)
        {
            ref Alpha16 p = ref _addr_p.val;

            if (p.Rect.Empty())
            {
                return true;
            }

            long i0 = 0L;
            var i1 = p.Rect.Dx() * 2L;
            for (var y = p.Rect.Min.Y; y < p.Rect.Max.Y; y++)
            {
                {
                    var i = i0;

                    while (i < i1)
                    {
                        if (p.Pix[i + 0L] != 0xffUL || p.Pix[i + 1L] != 0xffUL)
                        {
                            return false;
                        i += 2L;
                        }

                    }

                }
                i0 += p.Stride;
                i1 += p.Stride;

            }

            return true;

        }

        // NewAlpha16 returns a new Alpha16 image with the given bounds.
        public static ptr<Alpha16> NewAlpha16(Rectangle r)
        {
            return addr(new Alpha16(Pix:make([]uint8,pixelBufferLength(2,r,"Alpha16")),Stride:2*r.Dx(),Rect:r,));
        }

        // Gray is an in-memory image whose At method returns color.Gray values.
        public partial struct Gray
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<Gray> _addr_p)
        {
            ref Gray p = ref _addr_p.val;

            return color.GrayModel;
        }

        private static Rectangle Bounds(this ptr<Gray> _addr_p)
        {
            ref Gray p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<Gray> _addr_p, long x, long y)
        {
            ref Gray p = ref _addr_p.val;

            return p.GrayAt(x, y);
        }

        private static color.Gray GrayAt(this ptr<Gray> _addr_p, long x, long y)
        {
            ref Gray p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.Gray();
            }

            var i = p.PixOffset(x, y);
            return new color.Gray(p.Pix[i]);

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<Gray> _addr_p, long x, long y)
        {
            ref Gray p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 1L;
        }

        private static void Set(this ptr<Gray> _addr_p, long x, long y, color.Color c)
        {
            ref Gray p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            p.Pix[i] = color.GrayModel.Convert(c)._<color.Gray>().Y;

        }

        private static void SetGray(this ptr<Gray> _addr_p, long x, long y, color.Gray c)
        {
            ref Gray p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            p.Pix[i] = c.Y;

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<Gray> _addr_p, Rectangle r)
        {
            ref Gray p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new Gray());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new Gray(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<Gray> _addr_p)
        {
            ref Gray p = ref _addr_p.val;

            return true;
        }

        // NewGray returns a new Gray image with the given bounds.
        public static ptr<Gray> NewGray(Rectangle r)
        {
            return addr(new Gray(Pix:make([]uint8,pixelBufferLength(1,r,"Gray")),Stride:1*r.Dx(),Rect:r,));
        }

        // Gray16 is an in-memory image whose At method returns color.Gray16 values.
        public partial struct Gray16
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<Gray16> _addr_p)
        {
            ref Gray16 p = ref _addr_p.val;

            return color.Gray16Model;
        }

        private static Rectangle Bounds(this ptr<Gray16> _addr_p)
        {
            ref Gray16 p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<Gray16> _addr_p, long x, long y)
        {
            ref Gray16 p = ref _addr_p.val;

            return p.Gray16At(x, y);
        }

        private static color.Gray16 Gray16At(this ptr<Gray16> _addr_p, long x, long y)
        {
            ref Gray16 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.Gray16();
            }

            var i = p.PixOffset(x, y);
            return new color.Gray16(uint16(p.Pix[i+0])<<8|uint16(p.Pix[i+1]));

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<Gray16> _addr_p, long x, long y)
        {
            ref Gray16 p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 2L;
        }

        private static void Set(this ptr<Gray16> _addr_p, long x, long y, color.Color c)
        {
            ref Gray16 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            color.Gray16 c1 = color.Gray16Model.Convert(c)._<color.Gray16>();
            p.Pix[i + 0L] = uint8(c1.Y >> (int)(8L));
            p.Pix[i + 1L] = uint8(c1.Y);

        }

        private static void SetGray16(this ptr<Gray16> _addr_p, long x, long y, color.Gray16 c)
        {
            ref Gray16 p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            p.Pix[i + 0L] = uint8(c.Y >> (int)(8L));
            p.Pix[i + 1L] = uint8(c.Y);

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<Gray16> _addr_p, Rectangle r)
        {
            ref Gray16 p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new Gray16());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new Gray16(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<Gray16> _addr_p)
        {
            ref Gray16 p = ref _addr_p.val;

            return true;
        }

        // NewGray16 returns a new Gray16 image with the given bounds.
        public static ptr<Gray16> NewGray16(Rectangle r)
        {
            return addr(new Gray16(Pix:make([]uint8,pixelBufferLength(2,r,"Gray16")),Stride:2*r.Dx(),Rect:r,));
        }

        // CMYK is an in-memory image whose At method returns color.CMYK values.
        public partial struct CMYK
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect;
        }

        private static color.Model ColorModel(this ptr<CMYK> _addr_p)
        {
            ref CMYK p = ref _addr_p.val;

            return color.CMYKModel;
        }

        private static Rectangle Bounds(this ptr<CMYK> _addr_p)
        {
            ref CMYK p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<CMYK> _addr_p, long x, long y)
        {
            ref CMYK p = ref _addr_p.val;

            return p.CMYKAt(x, y);
        }

        private static color.CMYK CMYKAt(this ptr<CMYK> _addr_p, long x, long y)
        {
            ref CMYK p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return new color.CMYK();
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            return new color.CMYK(s[0],s[1],s[2],s[3]);

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<CMYK> _addr_p, long x, long y)
        {
            ref CMYK p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 4L;
        }

        private static void Set(this ptr<CMYK> _addr_p, long x, long y, color.Color c)
        {
            ref CMYK p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            color.CMYK c1 = color.CMYKModel.Convert(c)._<color.CMYK>();
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = c1.C;
            s[1L] = c1.M;
            s[2L] = c1.Y;
            s[3L] = c1.K;

        }

        private static void SetCMYK(this ptr<CMYK> _addr_p, long x, long y, color.CMYK c)
        {
            ref CMYK p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            var s = p.Pix.slice(i, i + 4L, i + 4L); // Small cap improves performance, see https://golang.org/issue/27857
            s[0L] = c.C;
            s[1L] = c.M;
            s[2L] = c.Y;
            s[3L] = c.K;

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<CMYK> _addr_p, Rectangle r)
        {
            ref CMYK p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new CMYK());
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new CMYK(Pix:p.Pix[i:],Stride:p.Stride,Rect:r,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<CMYK> _addr_p)
        {
            ref CMYK p = ref _addr_p.val;

            return true;
        }

        // NewCMYK returns a new CMYK image with the given bounds.
        public static ptr<CMYK> NewCMYK(Rectangle r)
        {
            return addr(new CMYK(Pix:make([]uint8,pixelBufferLength(4,r,"CMYK")),Stride:4*r.Dx(),Rect:r,));
        }

        // Paletted is an in-memory image of uint8 indices into a given palette.
        public partial struct Paletted
        {
            public slice<byte> Pix; // Stride is the Pix stride (in bytes) between vertically adjacent pixels.
            public long Stride; // Rect is the image's bounds.
            public Rectangle Rect; // Palette is the image's palette.
            public color.Palette Palette;
        }

        private static color.Model ColorModel(this ptr<Paletted> _addr_p)
        {
            ref Paletted p = ref _addr_p.val;

            return p.Palette;
        }

        private static Rectangle Bounds(this ptr<Paletted> _addr_p)
        {
            ref Paletted p = ref _addr_p.val;

            return p.Rect;
        }

        private static color.Color At(this ptr<Paletted> _addr_p, long x, long y)
        {
            ref Paletted p = ref _addr_p.val;

            if (len(p.Palette) == 0L)
            {
                return null;
            }

            if (!(new Point(x,y).In(p.Rect)))
            {
                return p.Palette[0L];
            }

            var i = p.PixOffset(x, y);
            return p.Palette[p.Pix[i]];

        }

        // PixOffset returns the index of the first element of Pix that corresponds to
        // the pixel at (x, y).
        private static long PixOffset(this ptr<Paletted> _addr_p, long x, long y)
        {
            ref Paletted p = ref _addr_p.val;

            return (y - p.Rect.Min.Y) * p.Stride + (x - p.Rect.Min.X) * 1L;
        }

        private static void Set(this ptr<Paletted> _addr_p, long x, long y, color.Color c)
        {
            ref Paletted p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            p.Pix[i] = uint8(p.Palette.Index(c));

        }

        private static byte ColorIndexAt(this ptr<Paletted> _addr_p, long x, long y)
        {
            ref Paletted p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return 0L;
            }

            var i = p.PixOffset(x, y);
            return p.Pix[i];

        }

        private static void SetColorIndex(this ptr<Paletted> _addr_p, long x, long y, byte index)
        {
            ref Paletted p = ref _addr_p.val;

            if (!(new Point(x,y).In(p.Rect)))
            {
                return ;
            }

            var i = p.PixOffset(x, y);
            p.Pix[i] = index;

        }

        // SubImage returns an image representing the portion of the image p visible
        // through r. The returned value shares pixels with the original image.
        private static Image SubImage(this ptr<Paletted> _addr_p, Rectangle r)
        {
            ref Paletted p = ref _addr_p.val;

            r = r.Intersect(p.Rect); 
            // If r1 and r2 are Rectangles, r1.Intersect(r2) is not guaranteed to be inside
            // either r1 or r2 if the intersection is empty. Without explicitly checking for
            // this, the Pix[i:] expression below can panic.
            if (r.Empty())
            {
                return addr(new Paletted(Palette:p.Palette,));
            }

            var i = p.PixOffset(r.Min.X, r.Min.Y);
            return addr(new Paletted(Pix:p.Pix[i:],Stride:p.Stride,Rect:p.Rect.Intersect(r),Palette:p.Palette,));

        }

        // Opaque scans the entire image and reports whether it is fully opaque.
        private static bool Opaque(this ptr<Paletted> _addr_p)
        {
            ref Paletted p = ref _addr_p.val;

            array<bool> present = new array<bool>(256L);
            long i0 = 0L;
            var i1 = p.Rect.Dx();
            for (var y = p.Rect.Min.Y; y < p.Rect.Max.Y; y++)
            {
                {
                    var c__prev2 = c;

                    foreach (var (_, __c) in p.Pix[i0..i1])
                    {
                        c = __c;
                        present[c] = true;
                    }

                    c = c__prev2;
                }

                i0 += p.Stride;
                i1 += p.Stride;

            }

            {
                var c__prev1 = c;

                foreach (var (__i, __c) in p.Palette)
                {
                    i = __i;
                    c = __c;
                    if (!present[i])
                    {
                        continue;
                    }

                    var (_, _, _, a) = c.RGBA();
                    if (a != 0xffffUL)
                    {
                        return false;
                    }

                }

                c = c__prev1;
            }

            return true;

        }

        // NewPaletted returns a new Paletted image with the given width, height and
        // palette.
        public static ptr<Paletted> NewPaletted(Rectangle r, color.Palette p)
        {
            return addr(new Paletted(Pix:make([]uint8,pixelBufferLength(1,r,"Paletted")),Stride:1*r.Dx(),Rect:r,Palette:p,));
        }
    }
}
