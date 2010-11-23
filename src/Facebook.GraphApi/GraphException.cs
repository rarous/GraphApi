namespace Facebook.GraphApi {

  using System;
  using System.Runtime.Serialization;

  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class GraphException : Exception {

    /// <summary>
    /// Constructs a new GraphException.
    /// </summary>
    /// <param name="message">The exception message</param>
    public GraphException(string message) 
      : base(message) {
    }

    public GraphException(string type, string message)
      : base(String.Format("{0}: {1}", type, message)) {
    }

    /// <summary>
    /// Constructs a new GraphException.
    /// </summary>
    /// <param name="message">The exception message</param>
    /// <param name="innerException">The inner exception</param>
    public GraphException(string message, Exception innerException) 
      : base(message, innerException) {
    }

    /// <summary>
    /// Serialization constructor.
    /// </summary>
    protected GraphException(SerializationInfo info, StreamingContext context)
      : base(info, context) {
    }
  }
}
