load 'XmlSectionParser.rb'
require 'minitest/autorun'

class XmlSectionParserTest < MiniTest::Unit::TestCase
  
  def setup
      @xmlSectionParser = XmlSectionParser.new() 
  end

  def testShouldReturnSectionContentIfMatched
      lineToMatch = "<AssemblyName>GridGCUIBase</AssemblyName>"
      parseResult = @xmlSectionParser.getMatchedSectionContent(lineToMatch, "AssemblyName")
      assert_equal "GridGCUIBase", parseResult
  end
  
  def testShouldReturnNilIfNotMatchedForContent
      lineToMatch = "<CanNotMatch>GridGCUIBase</CanNotMatch>"
      parseResult = @xmlSectionParser.getMatchedSectionContent(lineToMatch, "ToMatchSectionName")
      assert_nil parseResult
  end
  
  def testShouldReturnSectionPropertyIfMatched
      lineToMatch = '<Compile Include="GCGridFramework\GcLocalizationSlot.cs" />'
      parseResult = @xmlSectionParser.getMatchedSectionProperty(lineToMatch, "Compile Include")
      assert_equal "GCGridFramework\\GcLocalizationSlot.cs", parseResult
  end
  
  def testShouldReturnNilIfNotMatchedForProperty
      lineToMatch = '<CanNotMatch="GCGridFramework\GcLocalizationSlot.cs" />'
      parseResult = @xmlSectionParser.getMatchedSectionProperty(lineToMatch, "ToMatchSectionName")
      assert_nil parseResult
  end

end
