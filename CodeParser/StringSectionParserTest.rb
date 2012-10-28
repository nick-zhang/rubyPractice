load 'StringSectionParser.rb'
require 'minitest/autorun'

class StringSectionParserTest < MiniTest::Unit::TestCase

  def testShouldReturnSectionContentIfMatched
      lineToMatch = "<AssemblyName>GridGCUIBase</AssemblyName>"
      stringSParser = StringSectionParser.new()
      parseResult = stringSParser.getMatchedSectionContent(lineToMatch, "AssemblyName")
      assert_equal "GridGCUIBase", parseResult
  end
  
  def testShouldReturnSectionPropertyIfMatched
       lineToMatch = '<Compile Include="GCGridFramework\GcLocalizationSlot.cs" />'
       stringSParser = StringSectionParser.new()
       parseResult = stringSParser.getMatchedSectionProperty(lineToMatch, "Compile Include")
       assert_equal "GCGridFramework\\GcLocalizationSlot.cs", parseResult
   end

end
