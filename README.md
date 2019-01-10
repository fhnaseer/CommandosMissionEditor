# Master Branch Status: [![Build status](https://fhnaseer.visualstudio.com/PaaniStudio/_apis/build/status/CommandosMissionEditor_Master,)](https://fhnaseer.visualstudio.com/PaaniStudio/_build/latest?definitionId=0)

# Develop Branch Status: [![Build status](https://fhnaseer.visualstudio.com/PaaniStudio/_apis/build/status/CommandosMissionEditor_Develop,)](https://fhnaseer.visualstudio.com/PaaniStudio/_build/latest?definitionId=4)

# CommandosMissionEditor

A user interface for editing Commandos 2 mission files,

Tool can read a mis file, extract information, can add/remove/update commandos/soldier/patrols in the mission,
Currently we can perform only following actions,

Current functionality,
1. Add soldiers/patrols,
2. Add soldiers/patrols routes,
3. Add soldiers/patrols actions in a route,
4. Add commandos,
5. Set camera, music, briefing, etc.

Not done,
1. Actions for soldiers/patrols in a route,
2. Items in backpack for commandos and soldiers,
3. Objectives,
4. .INTERFAZ is not updated when a commando is added/removed from the mission,

File Reading Status,
1. Full -> We can read/write this information using the UI,
2. Partial -> Only some sections can be updated using the UI,
3. None -> We just read it and write it bacak when saving the file,

Here you can find what we can update in file and what we dont,
```
[
    .MANUAL_LIBRETA // Full,
    .VISORES // Full,
    [
        #indicates the cameras starting point
    ]
    .MUSICA // Full,
    [
        #defines the ingame music
    ]
    .BRIEFING // Full,
    [
        #defines the corresponding .bri file
    ]
    .MUNDO // Partial,
    [
        .FILE_GRUPOS_SCRIPT // Full,
        .INTENDENCIA // None,
        [
            .LISTAS_BICHOS
            (
                #defines key characters
            )
            .FLAGS
            (
                #defines event triggers
            ) 
            .FINMISION
            [
                #defines mission ending conditions
            ]
            .INFOJUG
            [
                #defines the objectives
            ]
            .REGLAS
            (
                #defines the rules for events to be triggered
            ) 
            .ZONAS
            (
                #defines areas where events will be triggered
            ) 
        ]
        .BICHOS // Partial - Only Commandos and Soldiers,
        (
            #defines the Objects available (Characters, items, animals, etc.)
        ) 
        .ENTES // Full,
        (
            #defines the patrols
        ) 
        .ZONASFLOTANTES // None,
        (
            #defines special areas
        ) 
        .SONIDOSAMBIENTE // None,
        (
            #defines ambient sounds in specific areas
        ) 
    ]
    .INTERFAZ // None,
    [
        .SUBINTERFACES
        (
            #defines specific interface abilities
        )
        .MULTIPLE
        [
            #defines generic interface abilities
        ]
    ]
    .FICHEROS // Full,
    [
        #defines the corresponding .str file
    ]
    .BAS // Full,
]
```
