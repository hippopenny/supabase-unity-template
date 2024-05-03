# Supabase Unity Template

Template to quickly get started using Supabase with Unity!

For more information on usage and step-by-step details
for how this template was created, check out the
documentation for the [Supabase-CSharp library](https://github.com/supabase-community/supabase-csharp),
as well as
the [Unity specific documentation](https://github.com/supabase-community/supabase-csharp/blob/master/Documentation/Unity.md).

From time to time Author posting videos on author's [YouTube channel](https://www.youtube.com/changenode) about Supabase and Unity, 
so check that out as well!

# Hippo Penny guide

Take a look on [Supabase for Unity](https://github.com/supabase-community/supabase-csharp/wiki/Unity) if they have any new requirements 

### Config project managed stripping
[Managed stripping is set to off/minimal](https://docs.unity3d.com/Manual/ManagedCodeStripping.html). This is mainly to avoid issues around code stripping removing constructors for JSON-related operations and reflection.
### Add these line of code to `proguard` file configurations
```
...
-keepattributes Signature
-keepattributes Annotation
-keepattributes EnclosingMethod
-keepattributes InnerClasses
```
### Setup deeplink configuration to redirect url after authenticate with 3rd party

1. Config deeplink for project with [Unity Docs](https://docs.unity3d.com/Manual/deep-linking.html) for both Android and IOS platform, the schema must be the same as app id `UnityEngine.Application.identifier`, for example `com.hippopenny.somegame`
2. Config redirect url on [Supabase](https://supabase.com/) at _Project_/Authentication/UrlConfiguration, click button AddURL. Url can be `com.hippopenny.supabaseexample://login-callback/` or only scheme without `login_callback`
   
![image](https://github.com/hippopenny/supabase-unity-template/assets/118701529/c130d6b6-a7d3-4615-a06b-ccf8d8b78572)

****Note** This deeplink url only work on device/emulator, please build `.apk` or release on testing environment 
