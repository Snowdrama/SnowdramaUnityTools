# Snowdrama's Unity Tools
Tools used by me!

This is a package of tools I have created and use in unity. This is kinda a catch all that doesn't have other ones.

Here's links to the other more specific packages: 

https://github.com/Snowdrama/SnowdramaUnityTagSystem

https://github.com/Snowdrama/SnowdramaUnityTimerTools

https://github.com/Snowdrama/SnowdramaUnitySpringTools

https://github.com/Snowdrama/SnowdramaUnityClassExtensions

https://github.com/Snowdrama/SnowdramaUnityUIRouterTools


# Requirements & Disclaimer
In theory it works with earlier versions but I have tested against 2020.3.19f1(current LTS version) but I have it set to work with 2019.1 and over so there may be issues if you're using 2019. There is also a dependency on Addressables since I use Addressables in some of my things.  

# Installation
* To install this package, use the Unity Package manager and click the + in the upper left.

![image](https://user-images.githubusercontent.com/1271916/139389113-88e7b032-0f93-42b2-ad80-10700baca435.png)
* Then use the https git URL(for example: https://github.com/Snowdrama/SnowdramaUnityTools.git)
* That should be it, wait for it to install and refresh and you're good to go!

# Samples
There's a few samples available for the things I think are most likely to be used, specifcially the UI Tools, Springs, and Timers(Menu Router coming soon)

![image](https://user-images.githubusercontent.com/1271916/139389332-5703d3ba-c155-471b-8bb4-f4110a5fa4a4.png)

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

Thanks for reading and hope these tools help you out!

![image](https://user-images.githubusercontent.com/1271916/139389860-e7517bf4-fb2c-4201-915c-c90d1935e7a2.png)

