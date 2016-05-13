Rules for Marquite extensions
===========

Custom builder classes
-----------
Custom builder classes should not contain any logic. They made only for helpers distinction. 
Public constructors for custom builder classes are prohibited. Construction of element should be 
exposed via corresponding extension methods.


Functional UI
-----------
All the possible UI in case of implementing frameworks should be done and exposed as extension methods sets to 
basic HTML builder or its specific inheritor.




Plugin policy
-----------
Plugin must contain implementor of IMarquitePlugin and be instantiated through extension method to HtmlHelper.
Instantiation must be done via .ResolvePlugin<> call to IMarquite instance gathered from HtmlHelper.

All the framework custom elemnts must be instantiable through extension methods to plugin class. 
There also should be parameterless instantiation method. 

Plugin must not expose any properties. Make them internal instead.

