// Copyright 2014 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// Implements methods to remove frames from profiles.

// package profile -- go2cs converted at 2020 August 29 08:24:21 UTC
// import "runtime/pprof/internal/profile" ==> using profile = go.runtime.pprof.@internal.profile_package
// Original source: C:\Go\src\runtime\pprof\internal\profile\prune.go
using fmt = go.fmt_package;
using regexp = go.regexp_package;
using static go.builtin;

namespace go {
namespace runtime {
namespace pprof {
namespace @internal
{
    public static partial class profile_package
    {
        // Prune removes all nodes beneath a node matching dropRx, and not
        // matching keepRx. If the root node of a Sample matches, the sample
        // will have an empty stack.
        private static void Prune(this ref Profile p, ref regexp.Regexp dropRx, ref regexp.Regexp keepRx)
        {
            var prune = make_map<ulong, bool>();
            var pruneBeneath = make_map<ulong, bool>();

            foreach (var (_, loc) in p.Location)
            {
                long i = default;
                for (i = len(loc.Line) - 1L; i >= 0L; i--)
                {
                    {
                        var fn = loc.Line[i].Function;

                        if (fn != null && fn.Name != "")
                        {
                            var funcName = fn.Name; 
                            // Account for leading '.' on the PPC ELF v1 ABI.
                            if (funcName[0L] == '.')
                            {
                                funcName = funcName[1L..];
                            }
                            if (dropRx.MatchString(funcName))
                            {
                                if (keepRx == null || !keepRx.MatchString(funcName))
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                if (i >= 0L)
                { 
                    // Found matching entry to prune.
                    pruneBeneath[loc.ID] = true; 

                    // Remove the matching location.
                    if (i == len(loc.Line) - 1L)
                    { 
                        // Matched the top entry: prune the whole location.
                        prune[loc.ID] = true;
                    }
                    else
                    {
                        loc.Line = loc.Line[i + 1L..];
                    }
                }
            }            foreach (var (_, sample) in p.Sample)
            { 
                // Scan from the root to the leaves to find the prune location.
                // Do not prune frames before the first user frame, to avoid
                // pruning everything.
                var foundUser = false;
                {
                    long i__prev2 = i;

                    for (i = len(sample.Location) - 1L; i >= 0L; i--)
                    {
                        var id = sample.Location[i].ID;
                        if (!prune[id] && !pruneBeneath[id])
                        {
                            foundUser = true;
                            continue;
                        }
                        if (!foundUser)
                        {
                            continue;
                        }
                        if (prune[id])
                        {
                            sample.Location = sample.Location[i + 1L..];
                            break;
                        }
                        if (pruneBeneath[id])
                        {
                            sample.Location = sample.Location[i..];
                            break;
                        }
                    }

                    i = i__prev2;
                }
            }
        }

        // RemoveUninteresting prunes and elides profiles using built-in
        // tables of uninteresting function names.
        private static error RemoveUninteresting(this ref Profile p)
        {
            ref regexp.Regexp keep = default;            ref regexp.Regexp drop = default;

            error err = default;

            if (p.DropFrames != "")
            {
                drop, err = regexp.Compile("^(" + p.DropFrames + ")$");

                if (err != null)
                {
                    return error.As(fmt.Errorf("failed to compile regexp %s: %v", p.DropFrames, err));
                }
                if (p.KeepFrames != "")
                {
                    keep, err = regexp.Compile("^(" + p.KeepFrames + ")$");

                    if (err != null)
                    {
                        return error.As(fmt.Errorf("failed to compile regexp %s: %v", p.KeepFrames, err));
                    }
                }
                p.Prune(drop, keep);
            }
            return error.As(null);
        }
    }
}}}}