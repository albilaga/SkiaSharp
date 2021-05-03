DirectoryPath ROOT_PATH = MakeAbsolute(Directory("../.."));
DirectoryPath OUTPUT_PATH = MakeAbsolute(ROOT_PATH.Combine("output/native"));

#load "../../cake/shared.cake"

Task("libSkiaSharp")
    .WithCriteria(IsRunningOnMac())
    .Does(() =>
{
    RunCake("../ios/build.cake", "libSkiaSharp", new Dictionary<string, string> {
        { "variant", "maccatalyst" },
    });
});

Task("libHarfBuzzSharp")
    .WithCriteria(IsRunningOnMac())
    .Does(() =>
{
    RunCake("../ios/build.cake", "libHarfBuzzSharp", new Dictionary<string, string> {
        { "variant", "maccatalyst" },
    });
});

Task("Default")
    .IsDependentOn("libSkiaSharp")
    .IsDependentOn("libHarfBuzzSharp");

RunTarget(TARGET);
