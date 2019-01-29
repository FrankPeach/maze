// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextMediaTypeFormatter.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the TextMediaTypeFormatter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Framework
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// The text media type formatter.
    /// </summary>
    public class TextMediaTypeFormatter : MediaTypeFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextMediaTypeFormatter"/> class.
        /// </summary>
        public TextMediaTypeFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }
        
        /// <inheritdoc/>
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            try
            {
                var memoryStream = new MemoryStream();
                readStream.CopyTo(memoryStream);
                var s = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                taskCompletionSource.SetResult(s);
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }

            return taskCompletionSource.Task;
        }

        /// <inheritdoc/>
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, System.Net.TransportContext transportContext, System.Threading.CancellationToken cancellationToken)
        {
            var buff = System.Text.Encoding.UTF8.GetBytes(value.ToString());
            return writeStream.WriteAsync(buff, 0, buff.Length, cancellationToken);
        }

        /// <inheritdoc/>
        public override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        /// <inheritdoc/>
        public override bool CanWriteType(Type type)
        {
            return type == typeof(string);
        }
    }
}