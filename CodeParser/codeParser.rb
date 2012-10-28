load 'XmlSectionParser.rb'

class CodeParser
  
@@xmlSectionParser = nil
 
def initialize()
  @@xmlSectionParser = XmlSectionParser.new()  
end
     
private   
def parseClassFrom(assemblyName, csFile)
   File.open(csFile, 'r') do |f1|  
     while line = f1.gets  
       if (/(public|internal) class/.match(line) != nil) 
           puts line.split(' ')[2] + ",#{assemblyName}," + csFile
       end
     end  
   end
end

private
def getCsFilesFromProjectFile(projectFile)
  csFilesMap = {}
  csFiles = []
  currentPath = File.dirname(projectFile)
  assemblyName = nil
    
  File.open(projectFile, 'r') do |f1|  
    while line = f1.gets
      tmpassemblyName =@@xmlSectionParser.getMatchedSectionContent(line, "AssemblyName")
      if (tmpassemblyName != nil)
         assemblyName = tmpassemblyName.strip
      end
       
      csFileName = @@xmlSectionParser.getMatchedSectionProperty(line, "Compile Include")
      if ( csFileName != nil)
        csFile = currentPath + "\\" + csFileName
        csFileReplaced = csFile.gsub("\\", "/")
        csFiles.push(csFileReplaced)
      end  
    end  
  end
  
  csFilesMap[assemblyName] = csFiles
  csFilesMap
end

public 
def getAllClassesFrom(root)
  csFiles = []
  Dir[root+"/**/*.csproj"].each{|s| File.path(s)}.each{|projectFile| csFiles.push(getCsFilesFromProjectFile(projectFile))}
  
  csFiles.each do |csfGroup|
    csfGroup.each_key do |assemble|
      csfGroup[assemble].each do |csFile|
        parseClassFrom(assemble, csFile)
      end
    end
  end
end

end

codeParser = CodeParser.new()
codeParser.getAllClassesFrom(".")

