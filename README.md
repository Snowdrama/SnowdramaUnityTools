# Snowdrama's Unity Tools
Tools used by me!

This is a package of all the tools I have created and use in unity from UI helpers, to springs, to scriptable objects.

# Overview Of Tools
* Attribute Fields
    * useful attribute fields for serialized fields like [EditorReadOnly], [SortingLayer], and [Password] attributes.
* Editor
    * Some tools I use to do things like quickly spliting large prefabs into sub prefabs, and generating materials from a folder of textures. Check the "Snow" tab in the menu bar at the top(Probably moving those at some point)
* Extensions
    * A set of extension methods that add simple functionality like checking if a layer mask contains a layer, or getting colors from gradients
* FileTools
    * Tools for reading and writing to files on disk(Currently Only JSON)
* HashNoise
    * A small RNG that uses noise to produce fast and good randomness. 
* Option Tools
    * A series of tools used for managing game settings using PlayerPrefs.
* Router
    * Tools for creating menu systems using a stack that includes for the ability to call a back function and go to the previous menu.
* ScriptableObjectExtension 
    * ScriptableObject containers for primitive types used for sharing decoupled runtime data 
* SimpleTools 
    * Basic debugging tools like, simple sphere and box gizmos.
* Timer Tools 
    * Simple Timer and Itterator tools for delayed execution without coroutines using callbacks
* UI Tools 
    * A series of tools to help manage layouts by calcualting the size for child objects.

# Samples
There's a few samples available for the things I think are most likely to be used, specifcially the UI Tools, Springs, and Timers(Menu Router coming soon)
