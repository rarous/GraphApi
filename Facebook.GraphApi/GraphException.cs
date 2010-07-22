using System;
using System.Runtime.Serialization;

namespace Facebook.GraphApi {
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class GraphException : Exception {
    // constructors...
    #region GraphException()
    /// <summary>
    /// Constructs a new GraphException.
    /// </summary>
    public GraphException() { }
    #endregion
    #region GraphException(string message)
    /// <summary>
    /// Constructs a new GraphException.
    /// </summary>
    /// <param name="message">The exception message</param>
    public GraphException(string message) : base(message) { }
    #endregion
    #region GraphException(string message, Exception innerException)
    /// <summary>
    /// Constructs a new GraphException.
    /// </summary>
    /// <param name="message">The exception message</param>
    /// <param name="innerException">The inner exception</param>
    public GraphException(string message, Exception innerException) : base(message, innerException) { }
    #endregion
    #region GraphException(SerializationInfo info, StreamingContext context)
    /// <summary>
    /// Serialization constructor.
    /// </summary>
    protected GraphException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    #endregion
  }
}
