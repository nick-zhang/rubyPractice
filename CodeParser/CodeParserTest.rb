load 'codeparser.rb'
require 'minitest/autorun'

class CodeParserTest < MiniTest::Unit::TestCase
  
  def testSimple
      codeParser = CodeParser.new()
      assert_equal 1, 1 
  end
  
end
