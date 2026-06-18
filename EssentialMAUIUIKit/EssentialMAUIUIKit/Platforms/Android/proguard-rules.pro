# Strip Log in release to avoid leaking sensitive info (CWE-532)
-assumenosideeffects class android.util.Log {
    public static int v(...);
    public static int d(...);
    public static int i(...);
    public static int w(...);
    public static int e(...);
    public static int wtf(...);
}

# Keep Syncfusion and MAUI reflection-heavy types
-keep class com.syncfusion.** { *; }
-keep class crc64** { *; }
-keep class mono.** { *; }
-keep class androidx.profileinstaller.** { *; }

# Optimize
-dontnote **
-dontwarn **
