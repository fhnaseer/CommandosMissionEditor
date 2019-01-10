using System;
using System.Reflection;
using System.Resources;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCompany("LMKR")]
[assembly: AssemblyProduct("LMKR SDK")]
[assembly: AssemblyCopyright("Copyright © 2012-2016 LMK Resources - All Rights Reserved")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:

// Version History

// Version 1.0.0 - created Feb 2012. This version was the first version used
// and was used in the LMKR License Management Tool (LMT). However, prior to 
// LMT being released some of the licensing libraries underwent major change.
// While these change had nothing to do with this SDK, the version was revised
// to 2.0.0.

// Version 2.0.0 - This version had some initial, although unused, Entity Framework (EF)
// data access based on .NET 4 and EF 4.0. This was the first release that
// made it to customers as part of LMT in Jan 2013 as part of the 
// GeoGraphix 2013 release.

// Version 3.0.0 - This version uses .NET 4.0 and Entity Framework (EF) 5.x. 
// This version is being created to support well path planning software.
// From this point forward the SDK will use Semantic Versioning as defined
// here: http://semver.org/
// This is a major release as we have migrated to a different version of
// .NET as the Entity Framework, therefore the change in the major version
// from 2 to 3.
// Update (22 May 2013): .NET 4.5 was not really needed so we took this version back to .NET 4.0.

// Version 4.0.0 - This version uses .NET 4.5.1, Entity Framework (EF) 5.x and Sybase 12,
// Version 4.1.0 - This version uses .NET 4.5.1, Entity Framework (EF) 6.x and Sybase 17,

// Version 5.1.0 - This version will have a lot of refactoring and new apis related to 3d and seismic,
// No change in .NET framework, Entity Framework and Sybase,
[assembly: AssemblyVersion("5.0.0.0")]
[assembly: AssemblyFileVersion("5.0.0.0")]
[assembly: AssemblyInformationalVersion("5.0.0.0")]
[assembly: NeutralResourcesLanguageAttribute("en-US")]
[assembly: CLSCompliant(true)]
