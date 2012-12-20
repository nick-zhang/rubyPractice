load 'CaesarEncrypter.rb'
require 'minitest/autorun'

class CaesarTest < MiniTest::Unit::TestCase
  
  # Simple test here to show how to use MiniTest, but nonsense
  def testShouldEncryptWithSingleLetter
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('a')
      assert_equal 'd', encrypted 
  end
end
