using System;
using System.Collections.Generic;
using System.Web;

namespace Facebook.GraphApi {

  [Flags]
  public enum Permissions : long {
    None = 0,
    PublishStream = 1,
    CreateEvent = 2,
    RsvpEvent = 4,
    Sms = 8,
    OfflineAccess = 16,
    ManagePages = 32,
    Email = 64,
    ReadInsights = 128,
    ReadStream = 256,
    ReadMailbox = 512,
    AdsManagement = 1024,
    XmppLogin = 2048,
    UserAboutMe = 4096,
    UserActivities = 8192,
    UserBirthday = 16348,
    UserEducationHistory = 32768,
    UserEvents = 65536,
    UserGroups = 131072,
    UserHometown = 262144,
    UserInterests = 524288,
    UserLikes = 1048576,
    UserLocation = 2097152,
    UserNotes = 4194304,
    UserOnlinePresence = 8388608,
    UserPhotoVideoTags = 16777216,
    UserPhotos = 33554432,
    UserRelationships = 67108864,
    UserReligionPolitics = 134217728,
    UserStatus = 268435456,
    UserVideos = 536870912,
    UserWebsite = 1073741824,
    UserWorkHistory = 2147483648,
    ReadFriendlists = 4294967296,
    ReadRequests = 8589934592,
  }
}
