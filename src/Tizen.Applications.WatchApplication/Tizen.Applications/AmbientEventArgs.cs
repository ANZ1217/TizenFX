﻿/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using ElmSharp;
using System;

namespace Tizen.Applications
{
    /// <summary>
    /// Arguments for the event that are raised when the device enters or exits the ambient mode.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API10. Will be removed in API12.")]
    public class AmbientEventArgs : EventArgs
    {
        /// <summary>
        /// The received ambient mode.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool Enabled { get; internal set; }

        internal AmbientEventArgs()
        {
        }
    }
}