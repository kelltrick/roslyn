﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using Microsoft.CodeAnalysis;

namespace Roslyn.Utilities
{
    /// <summary>
    /// Catches exceptions thrown during disposal of the underlying stream and
    /// writes them to the given <see cref="TextWriter"/>. Check
    /// <see cref="HasFailedToDispose" /> after disposal to see if any
    /// exceptions were thrown during disposal.
    /// </summary>
    internal class NoThrowStreamDisposer : IDisposable
    {
        private bool? _failed; // Nullable to assert that this is only checked after dispose
        private readonly string _filePath;
        private readonly TextWriter _writer;
        private readonly CommonMessageProvider _messageProvider;

        /// <summary>
        /// Underlying stream
        /// </summary>
        public Stream Stream { get; }

        /// <summary>
        /// True iff an exception was thrown during a call to <see cref="Dispose"/>
        /// </summary>
        public bool HasFailedToDispose
        {
            get
            {
                Debug.Assert(_failed != null);
                return _failed.GetValueOrDefault();
            }
        }
        
        public NoThrowStreamDisposer(
            Stream stream,
            string filePath,
            TextWriter writer,
            CommonMessageProvider messageProvider)
        {
            Stream = stream;
            _failed = null;
            _filePath = filePath;
            _writer = writer;
            _messageProvider = messageProvider;
        }

        public void Dispose()
        {
            Debug.Assert(_failed == null);
            try
            {
                Stream.Dispose();
                if (_failed == null)
                {
                    _failed = false;
                }
            }
            catch (Exception e)
            {
                _messageProvider.ReportStreamWriteException(e, _filePath, _writer);
                // Record if any exceptions are thrown during dispose
                _failed = true;
            }
        }
    }
}
