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
 
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    
    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class TriggerBase : BindableObject, IAttachedObject
    {
        bool _isSealed;

        internal TriggerBase(Type targetType)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));
            TargetType = targetType;

            EnterActions = new SealedList<TriggerAction>();
            ExitActions = new SealedList<TriggerAction>();
        }

        internal TriggerBase(Condition condition, Type targetType) : this(targetType)
        {
            Setters = new SealedList<Setter>();
            Condition = condition;
            Condition.ConditionChanged = OnConditionChanged;
        }

        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<TriggerAction> EnterActions { get; }

        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<TriggerAction> ExitActions { get; }

        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSealed
        {
            get { return _isSealed; }
            private set
            {
                if (_isSealed == value)
                    return;
                if (!value)
                    throw new InvalidOperationException("What is sealed can not be unsealed.");
                _isSealed = value;
                OnSeal();
            }
        }

        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Type TargetType { get; }

        internal Condition Condition { get; }

        //Setters and Condition are used by Trigger, DataTrigger and MultiTrigger
        internal IList<Setter> Setters { get; }

        void IAttachedObject.AttachTo(BindableObject bindable)
        {
            IsSealed = true;

            if (bindable == null)
                throw new ArgumentNullException(nameof(bindable));
            if (!TargetType.IsInstanceOfType(bindable))
                throw new InvalidOperationException("bindable not an instance of AssociatedType");
            OnAttachedTo(bindable);
        }

        void IAttachedObject.DetachFrom(BindableObject bindable)
        {
            if (bindable == null)
                throw new ArgumentNullException(nameof(bindable));
            OnDetachingFrom(bindable);
        }

        internal virtual void OnAttachedTo(BindableObject bindable)
        {
            if (Condition != null)
                Condition.SetUp(bindable);
        }

        internal virtual void OnDetachingFrom(BindableObject bindable)
        {
            if (Condition != null)
                Condition.TearDown(bindable);
        }

        internal virtual void OnSeal()
        {
            ((SealedList<TriggerAction>)EnterActions).IsReadOnly = true;
            ((SealedList<TriggerAction>)ExitActions).IsReadOnly = true;
            if (Setters != null)
                ((SealedList<Setter>)Setters).IsReadOnly = true;
            if (Condition != null)
                Condition.IsSealed = true;
        }

        void OnConditionChanged(BindableObject bindable, bool oldValue, bool newValue)
        {
            if (newValue)
            {
                foreach (TriggerAction action in EnterActions)
                    action.DoInvoke(bindable);
                foreach (Setter setter in Setters)
                    setter.Apply(bindable);
            }
            else
            {
                foreach (Setter setter in Setters)
                    setter.UnApply(bindable);
                foreach (TriggerAction action in ExitActions)
                    action.DoInvoke(bindable);
            }
        }

        internal class SealedList<T> : IList<T>, IList
        {
            readonly IList<T> _actual;

            bool _isReadOnly;

            public SealedList()
            {
                _actual = new List<T>();
            }

            public void Add(T item)
            {
                if (IsReadOnly)
                    throw new InvalidOperationException("This list is ReadOnly");
                _actual.Add(item);
            }

            public void Clear()
            {
                if (IsReadOnly)
                    throw new InvalidOperationException("This list is ReadOnly");
                _actual.Clear();
            }

            public bool Contains(T item)
            {
                return _actual.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                _actual.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return _actual.Count; }
            }

            public bool IsReadOnly
            {
                get { return _isReadOnly; }
                set
                {
                    if (_isReadOnly == value)
                        return;
                    if (!value)
                        throw new InvalidOperationException("Can't change this back to non read-only");
                    _isReadOnly = value;
                }
            }

            public bool IsFixedSize => throw new NotImplementedException();

            public bool IsSynchronized => throw new NotImplementedException();

            public object SyncRoot => throw new NotImplementedException();

            object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public bool Remove(T item)
            {
                if (IsReadOnly)
                    throw new InvalidOperationException("This list is ReadOnly");
                return _actual.Remove(item);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)_actual).GetEnumerator();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _actual.GetEnumerator();
            }

            public int IndexOf(T item)
            {
                return _actual.IndexOf(item);
            }

            public void Insert(int index, T item)
            {
                if (IsReadOnly)
                    throw new InvalidOperationException("This list is ReadOnly");
                _actual.Insert(index, item);
            }

            public T this[int index]
            {
                get { return _actual[index]; }
                set
                {
                    if (IsReadOnly)
                        throw new InvalidOperationException("This list is ReadOnly");
                    _actual[index] = value;
                }
            }

            public void RemoveAt(int index)
            {
                if (IsReadOnly)
                    throw new InvalidOperationException("This list is ReadOnly");
                _actual.RemoveAt(index);
            }

            public int Add(object value)
            {
                Add((T)value);
                return _actual.Count;
            }

            public bool Contains(object value)
            {
                return Contains((T)value);
            }

            public int IndexOf(object value)
            {
                return IndexOf((T)value);
            }

            public void Insert(int index, object value)
            {
                Insert(index, (T)value);
            }

            public void Remove(object value)
            {
                Remove((T)value);
            }

            public void CopyTo(Array array, int index)
            {
                CopyTo((T[])array, index);
            }
        }
    }
}
