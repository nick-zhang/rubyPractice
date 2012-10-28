class XmlSectionParser
public
  def getMatchedSectionContent(lineToMatch, sectionName)
    if (/#{sectionName}/.match(lineToMatch) != nil) 
        replacedStart = lineToMatch.gsub("<#{sectionName}>", "")
        sectionContent = replacedStart.gsub("</#{sectionName}>", "")
        return sectionContent
    end
    nil
  end
  
public  
  def getMatchedSectionProperty(lineToMatch, sectionName)
    if (/#{sectionName}=/.match(lineToMatch) != nil) 
        property = lineToMatch.split('"')[1]
        return property
    end
    nil
  end
  
end
