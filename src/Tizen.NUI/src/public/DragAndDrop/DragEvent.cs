/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for the drag source event types.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum DragSourceEventType
    {
        /// <summary>
        /// Indicates that the drag and drop operation has started.
        /// </summary>
        Start,
        /// <summary>
        /// Indicates that the drag and drop operation has been cancelled.
        /// </summary>
        Cancel,
        /// <summary>
        /// Indicates that the drag and drop operation has been accepted by the target.
        /// </summary>
        Accept,
        /// <summary>
        /// Indicates that the drag and drop operation has finished.
        /// </summary>
        Finish
    }

    /// <summary>
    /// This specifies drag data.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    // Suppress warning : This struct will be used data of callback, so override equals and operator does not necessary.
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815: Override equals and operator equals on value types")]
    public struct DragData
    {
        /// <summary>
        /// The mime type of drag data
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// The drag data to send
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// The mime types and drag data set
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dictionary<string, string> DataMap;
    }

    /// <summary>
    /// This enumeration defines the different types of drag events that can occur when a drag-and-drop operation is performed on a target view.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum DragType
    {
        /// <summary>
        /// The drag object has entered the target view.
        /// </summary>
        Enter,
        /// <summary>
        /// The drag object has leaved the target view.
        /// </summary>
        Leave,
        /// <summary>
        /// The drag object moves in the target view.
        /// </summary>
        Move,
        /// <summary>
        /// The drag object dropped in the target view.
        /// </summary>
        Drop
    }

    /// <summary>
    /// This specifies drag event.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    // Suppress warning : This struct will be used data of callback, so override equals and operator does not necessary.
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815: Override equals and operator equals on value types")]
    public struct DragEvent
    {
        /// <summary>
        /// The drag event type
        /// </summary>
        public DragType DragType { get; set; }
        /// <summary>
        /// The drag object position in target view
        /// </summary>
        public Position Position  { get; set; }
        /// <summary>
        /// The mime type of drag object
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// The mime types of drag object
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string [] MimeTypes { get; set; }

        /// <summary>
        /// The drag data to receive
        /// </summary>
        public string Data { get; set; }
    }
}
