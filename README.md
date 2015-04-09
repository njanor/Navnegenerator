# Navnegenerator

This repo supplies a random name generator for Norwegian names.

It _should_ provide names with a distribution which is similar to that of the most popular names of the newest version of Statistisk sentralbyrås (SSB) latest published statistics.

**Note:** The SSB statistics does not include names which have been used fewer than 200 times during a given year.

_SSB source:_ http://www.ssb.no/navn/

## Example of use

After installing the NuGet-package, it _should_ be to simply use one of the following generator methods:
```csharp
var generator = new Generator(); // A new generator (loads names)
generator.GenererNyttKvinnenavn(); // A new name for a woman
generator.GenererNyttHerrenavn(); // A new name for a man
generator.GenererNyttNavn(); // A new name which could be for a woman or a man
```
