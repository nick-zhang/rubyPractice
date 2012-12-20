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
  
  def testShouldEncryptWithTheEndSingleLowercase
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('z')
      assert_equal 'c', encrypted 
  end
end
