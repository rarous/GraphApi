using System;

namespace Facebook.GraphApi {

  [Flags]
  public enum HttpVerb {
    Get,
    Post,
    Put,
    Delete,
    Head,
  }
}
