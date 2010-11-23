namespace Facebook.GraphApi {

  using System;
  using System.Runtime.Serialization;

  /// <summary>
  /// Exception thrown by <see cref="ClientAuth"/>.
  /// </summary>
  [Serializable]
  public class ClientAuthException : Exception {
    // constructors...
    #region ClientAuthException()
    /// <summary>
    /// Constructs a new ClientAuthException.
    /// </summary>
    public ClientAuthException() { }
    #endregion
    #region ClientAuthException(string message)
    /// <summary>
    /// Constructs a new ClientAuthException.
    /// </summary>
    /// <param name="message">The exception message</param>
    public ClientAuthException(string message) : base(message) { }
    #endregion
    #region ClientAuthException(string message, Exception innerException)
    /// <summary>
    /// Constructs a new ClientAuthException.
    /// </summary>
    /// <param name="message">The exception message</param>
    /// <param name="innerException">The inner exception</param>
    public ClientAuthException(string message, Exception innerException) : base(message, innerException) { }
    #endregion
    #region ClientAuthException(SerializationInfo info, StreamingContext context)
    /// <summary>
    /// Serialization constructor.
    /// </summary>
    protected ClientAuthException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    #endregion
  }
}
