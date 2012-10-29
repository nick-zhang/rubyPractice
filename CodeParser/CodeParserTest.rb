load 'codeparser.rb'
require 'minitest/autorun'

class CodeParserTest < MiniTest::Unit::TestCase
  
  # Simple test here to show how to use MiniTest, but nonsense
  def testSimple
      codeParser = CodeParser.new()
      assert_equal 1, 1 
  end
  
end
