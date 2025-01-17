// Copyright 2017 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package cache -- go2cs converted at 2020 October 09 05:46:00 UTC
// import "cmd/go/internal/cache" ==> using cache = go.cmd.go.@internal.cache_package
// Original source: C:\Go\src\cmd\go\internal\cache\default.go
using fmt = go.fmt_package;
using ioutil = go.io.ioutil_package;
using os = go.os_package;
using filepath = go.path.filepath_package;
using sync = go.sync_package;

using @base = go.cmd.go.@internal.@base_package;
using cfg = go.cmd.go.@internal.cfg_package;
using static go.builtin;
using System;

namespace go {
namespace cmd {
namespace go {
namespace @internal
{
    public static partial class cache_package
    {
        // Default returns the default cache to use, or nil if no cache should be used.
        public static ptr<Cache> Default()
        {
            defaultOnce.Do(initDefaultCache);
            return _addr_defaultCache!;
        }

        private static sync.Once defaultOnce = default;        private static ptr<Cache> defaultCache;

        // cacheREADME is a message stored in a README in the cache directory.
        // Because the cache lives outside the normal Go trees, we leave the
        // README as a courtesy to explain where it came from.
        private static readonly @string cacheREADME = (@string)"This directory holds cached build artifacts from the Go build system.\nRun \"go cle" +
    "an -cache\" if the directory is getting too large.\nSee golang.org to learn more a" +
    "bout Go.\n";

        // initDefaultCache does the work of finding the default cache
        // the first time Default is called.


        // initDefaultCache does the work of finding the default cache
        // the first time Default is called.
        private static void initDefaultCache()
        {
            var dir = DefaultDir();
            if (dir == "off")
            {
                if (defaultDirErr != null)
                {
                    @base.Fatalf("build cache is required, but could not be located: %v", defaultDirErr);
                }

                @base.Fatalf("build cache is disabled by GOCACHE=off, but required as of Go 1.12");

            }

            {
                var err = os.MkdirAll(dir, 0777L);

                if (err != null)
                {
                    @base.Fatalf("failed to initialize build cache at %s: %s\n", dir, err);
                }

            }

            {
                var (_, err) = os.Stat(filepath.Join(dir, "README"));

                if (err != null)
                { 
                    // Best effort.
                    ioutil.WriteFile(filepath.Join(dir, "README"), (slice<byte>)cacheREADME, 0666L);

                }

            }


            var (c, err) = Open(dir);
            if (err != null)
            {
                @base.Fatalf("failed to initialize build cache at %s: %s\n", dir, err);
            }

            defaultCache = c;

        }

        private static sync.Once defaultDirOnce = default;        private static @string defaultDir = default;        private static error defaultDirErr = default!;

        // DefaultDir returns the effective GOCACHE setting.
        // It returns "off" if the cache is disabled.
        public static @string DefaultDir()
        { 
            // Save the result of the first call to DefaultDir for later use in
            // initDefaultCache. cmd/go/main.go explicitly sets GOCACHE so that
            // subprocesses will inherit it, but that means initDefaultCache can't
            // otherwise distinguish between an explicit "off" and a UserCacheDir error.

            defaultDirOnce.Do(() =>
            {
                defaultDir = cfg.Getenv("GOCACHE");
                if (filepath.IsAbs(defaultDir) || defaultDir == "off")
                {
                    return ;
                }

                if (defaultDir != "")
                {
                    defaultDir = "off";
                    defaultDirErr = fmt.Errorf("GOCACHE is not an absolute path");
                    return ;
                } 

                // Compute default location.
                var (dir, err) = os.UserCacheDir();
                if (err != null)
                {
                    defaultDir = "off";
                    defaultDirErr = fmt.Errorf("GOCACHE is not defined and %v", err);
                    return ;
                }

                defaultDir = filepath.Join(dir, "go-build");

            });

            return defaultDir;

        }
    }
}}}}
