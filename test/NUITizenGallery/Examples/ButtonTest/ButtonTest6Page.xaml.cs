/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ButtonTest6Page : ContentPage
    {
        private TapGestureDetector mTapDetector;
        public ButtonTest6Page()
        {
            InitializeComponent();

            mTapDetector = new TapGestureDetector();
            mTapDetector.Attach(redText);
            mTapDetector.Attach(greenText);
            mTapDetector.Attach(grayText);

            mTapDetector.Detected += (obj, e) =>
            {
                View view = e.View;
                if (view != null)
                {
                    button1.BackgroundColor = view.BackgroundColor;
                }
            };
        }
    }
}