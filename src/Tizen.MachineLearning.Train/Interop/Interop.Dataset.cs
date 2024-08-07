/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;
using System.Runtime.InteropServices;
using Tizen.MachineLearning.Train;

internal static partial class Interop
{
    internal static partial class Dataset
    {
        /* int ml_train_dataset_create(ml_train_dataset_h *dataset) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_dataset_create")]
        public static extern NNTrainerError Create(out IntPtr datasetHandle);

        /* int ml_train_dataset_destroy(ml_train_dataset_h dataset) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_dataset_destroy")]
        public static extern NNTrainerError Destroy(IntPtr datasetHandle);

        /* int ml_train_dataset_add_file(ml_train_dataset_h dataset, ml_train_dataset_mode_e mode, const char *file) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_dataset_add_file")]
        internal static extern NNTrainerError AddFile(IntPtr datasetHandle, NNTrainerDatasetMode mode, string file);

        /* int ml_train_dataset_set_property_for_mode_with_single_param(ml_train_dataset_h dataset, ml_train_dataset_mode_e mode, const char *single_param) */
        [DllImport(Libraries.Nntrainer, EntryPoint = "ml_train_dataset_set_property_for_mode_with_single_param")]
        internal static extern NNTrainerError SetProperty(IntPtr datasetHandle, NNTrainerDatasetMode mode, string propertyParams);
    }
}
