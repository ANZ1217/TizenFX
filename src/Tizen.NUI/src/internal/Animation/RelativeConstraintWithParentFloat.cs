/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    using global::System.Runtime.InteropServices;

    /// <summary>
    /// Specialized Constraint.
    /// Make handle's targetIndex value always equal with handle's parent's parentIndex value
    /// </summary>
    internal sealed class RelativeConstraintWithParentFloat : Constraint
    {
        internal RelativeConstraintWithParentFloat(HandleRef handle, int targetIndex, int parentIndex, float rate)
         : base(Interop.Constraint.NewRelativeConstraintWithParentFloat(handle, targetIndex, parentIndex, rate), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }
    }
}
