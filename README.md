# Native Function Hook

Grand Theft Auto V variant to Native Function Hook.

It adds new properties and methods to native entities such as `Ped`s, `Entity`s, `Vehicle`s; It also adds new properties and functions to `Game`, `World` static classes to expand general game and game world functionalities.

## How to Reference

Build it and reference the assembly file. Submodule is not recommended.

## FAQs

#### I have been told to come here and get a `dll` file.

Currently no `.dll` files have been released, but authors is authorized to re-publish dll files they've built. Ask the author to add their files to the archive unless it is modified.

#### I got a DLL Hell of this library.

When there's a binary release, most of DLL Hells may got resolved.

*DLL Hell: Multiple applications requires different version of DLL files but they end up referencing only one version of DLL files, causing some of or all of the them having malfunction, crashes, or don't event boot up.*

#### I see you re-implementing nearly all of functions in Entity class.

That is because the production of this library has been staged to three parts:

1. Release additions to `SHVDN` API version 2, but internally it will end up implement anything in `SHVDN` API.
2. Release API to the `SHVDN` core ASI file.
3. Release a independent core with this API, and loads scripts on it's own.

Currently it is part 1.