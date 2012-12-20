load 'CaesarEncrypter.rb'
require 'minitest/autorun'

class CaesarTest < MiniTest::Unit::TestCase
  
  def testShouldEncryptWithSingleLowercase
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('a')
      assert_equal 'd', encrypted 
  end
  
  def testShouldEncryptWithSingleUppercase
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('A')
      assert_equal 'D', encrypted 
  end
  
end
