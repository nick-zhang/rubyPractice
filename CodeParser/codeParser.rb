load 'StringSectionParser.rb'

class CodeParser
  
private   
def parseClassFrom(csFile)
   File.open(csFile, 'r') do |f1|  
     while line = f1.gets  
       if (/(public|internal) class/.match(line) != nil) 
           puts line.split(' ')[2] + " " + csFile
       end
     end  
   end
end

private
def getCsFilesFromProjectFile(projectFile)
  csFiles = []
  currentPath = File.dirname(projectFile)
  stringSectionParser = StringSectionParser.new()
  
  File.open(projectFile, 'r') do |f1|  
    while line = f1.gets 
      csFileName = stringSectionParser.getMatchedSectionProperty(line, "Compile Include")
      if ( csFileName != nil)
        csFile = currentPath + "\\" + csFileName
        csFileReplaced = csFile.gsub("\\", "/")
        csFiles.push(csFileReplaced)
      end  
    end  
  end
  csFiles
end

public 
def getAllClassesFrom(root)
  csFiles = []
  Dir[root+"/**/*.csproj"].each{|s| File.path(s)}.each{|projectFile| csFiles.push(getCsFilesFromProjectFile(projectFile))}
  
  csFiles.each do |csfGroup|
    csfGroup.each do |csfSingle|
      parseClassFrom(csfSingle)
    end
  end
end

end

codeParser = CodeParser.new()
codeParser.getAllClassesFrom(".")

