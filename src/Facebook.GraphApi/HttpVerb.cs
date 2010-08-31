using System;

namespace Facebook.GraphApi {

  [Flags]
  public enum HttpVerb {
    Get = 0x1,
    Post = 0x2,
    Delete = 0x4,
  }
}
