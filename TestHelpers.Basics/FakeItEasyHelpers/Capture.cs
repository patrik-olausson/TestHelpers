﻿using System;
using System.Collections.Generic;
using FakeItEasy;

namespace TestHelpers.Basics.FakeItEasyHelpers
{
    /// <summary>
    /// Create a container to capture parameter values passed into a FakeItEasy fake.
    /// </summary>
    /// <example>
    /// var capture = new Capture&lt;int&gt;();
    /// A.CallTo(() => fake.SomeMethod(capture);
    /// fake.SomeMethod(42);
    /// int capturedValue = capture.Value;
    /// </example>
    /// <returns>A capture container that can be used in A.CallTo(...)</returns>
    /// <remarks>
    /// Original code copied from http://thorarin.net/blog/post/2014/09/18/capturing-method-arguments-on-your-fakes-using-fakeiteasy.aspx
    /// </remarks>
    public sealed class Capture<T>
    {
        private readonly List<T> _values = new List<T>();
        private bool _pendingConfiguration = true;

        /// <summary>
        /// The captured value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when no values have been captured, or when more than one value was captured.</exception>
        public T Value
        {
            get
            {
                if (_values.Count == 0) throw new InvalidOperationException("No values have been captured.");
                if (_values.Count > 1) throw new InvalidOperationException("Multiple values were captured. Use Values property instead.");

                return _values[0];
            }
        }

        /// <summary>
        /// The list captured values.
        /// </summary>
        public IReadOnlyList<T> Values => _values.AsReadOnly();

        private void CaptureValue(T value)
        {
            _values.Add(value);
        }

        /// <summary>
        /// Returns true if at least one value was captured.
        /// </summary>
        public bool HasValues => _values.Count > 0;

        public override string ToString()
        {
            if (_values.Count == 0) return "No captured values";
            if (_values.Count == 1) return Value.ToString();

            return $"{Values.Count} captured values";
        }

        public static implicit operator T(Capture<T> capture)
        {
            if (!capture._pendingConfiguration) throw new InvalidOperationException("Capture can only be used to configure a single call. If you're trying to access the captured value, use the Value property instead of relying on an implicit conversion.");

            // Some FakeItEasy trickery to get the parameter value
            A<T>.That.Matches(input => { capture.CaptureValue(input); return true; }, "Captured parameter " + typeof(T).FullName);
            capture._pendingConfiguration = false;

            return default(T);
        }
    }
}