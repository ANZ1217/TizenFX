﻿/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the property map of the gradient visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class GradientVisual : VisualMap
    {
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private Vector2 _center;
        private float? _radius;
        private PropertyArray _stopOffset;
        private PropertyArray _stopColor;
        private GradientVisualUnitsType? _units;
        private GradientVisualSpreadMethodType? _spreadMethod;
        private float? _startOffset;
        private float? _startAngle;

        /// <summary>
        /// Default constructor of GradientVisual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GradientVisual() : base()
        {
        }

        /// <summary>
        /// Gets or sets the start position of a linear gradient.<br />
        /// Mandatory for linear.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 StartPosition
        {
            get
            {
                return _startPosition;
            }
            set
            {
                _startPosition = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the end position of a linear gradient.<br />
        /// Mandatory for linear.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 EndPosition
        {
            get
            {
                return _endPosition;
            }
            set
            {
                _endPosition = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the center point of a radial gradient.<br />
        /// Mandatory for radial and conic.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 Center
        {
            get
            {
                return _center;
            }
            set
            {
                _center = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the size of the radius of a radial gradient.<br />
        /// Mandatory for radial.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Radius
        {
            get
            {
                return _radius ?? (-1.0f);
            }
            set
            {
                _radius = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets all the stop offsets.<br />
        /// A PropertyArray of float.<br />
        /// If not supplied, the default is 0.0f and 1.0f.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray StopOffset
        {
            get
            {
                return _stopOffset;
            }
            set
            {
                _stopOffset = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the color at the stop offsets.<br />
        /// A PropertyArray of color.<br />
        /// At least 2 values are required to show a gradient.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray StopColor
        {
            get
            {
                return _stopColor;
            }
            set
            {
                _stopColor = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets descriptions of the coordinate system for certain attributes of the points in a gradient.<br />
        /// If not supplied, the default is GradientVisualUnitsType.ObjectBoundingBox.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GradientVisualUnitsType Units
        {
            get
            {
                return _units ?? (GradientVisualUnitsType.ObjectBoundingBox);
            }
            set
            {
                _units = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets indications of what happens if the gradient starts or ends inside the bounds of the target rectangle.<br />
        /// If not supplied, the default is GradientVisualSpreadMethodType.Pad.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GradientVisualSpreadMethodType SpreadMethod
        {
            get
            {
                return _spreadMethod ?? (GradientVisualSpreadMethodType.Pad);
            }
            set
            {
                _spreadMethod = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the gradient's start position offset.<br />
        /// If not supplied, the default is 0.0f.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float StartOffset
        {
            get
            {
                return _startOffset ?? (0.0f);
            }
            set
            {
                _startOffset = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the start angle of the conic gradient.<br />
        /// Mandatory for conic.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float StartAngle
        {
            get
            {
                return _startAngle ?? (0.0f);
            }
            set
            {
                _startAngle = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (((_startPosition != null && _endPosition != null) || (_center != null && _radius != null)) && _stopColor != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, (int)Visual.Type.Gradient);
                _outputVisualMap.Add(GradientVisualProperty.StopColor, _stopColor);

                if (_startPosition != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.StartPosition, _startPosition);
                }

                if (_endPosition != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.EndPosition, _endPosition);
                }

                if (_center != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.Center, _center);
                }

                if (_radius != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.Radius, (float)_radius);
                }

                if (_stopOffset != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.StopOffset, _stopOffset);
                }

                if (_units != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.Units, (int)_units);
                }

                if (_spreadMethod != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.SpreadMethod, (int)_spreadMethod);
                }

                if (_startOffset != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.StartOffset, (float)_startOffset);
                }
                base.ComposingPropertyMap();
            }
        }
    }
}
