New Suppressions:

CA 1059 Member should not expose concrete types in LevelLoader - 
The main benefit of these functions revolves around the ability to deserialize a XMLReader. 
The preferred generic type is not compatible with any of the reader classes. 
Hence, it's just as well that we pass in the XMLNode type. In the future, it would be possible to create one type of loading function, in which case there would be no exposed concrete types.
This is not feasible in the scope of this Sprint.

CA1502 CA1809 Large cyclomatic complexity of collision detection - 
We began to implement a unified collision class that would eliminate cyclomatic complexity issues. However, due to communication issues, new features became incompatible, and we had to roll back. 
We recognize this is an ongoing issue, and future work would allow us to address it. 




