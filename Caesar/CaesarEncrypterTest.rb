load 'CaesarEncrypter.rb'
require 'minitest/autorun'

class CaesarTest < MiniTest::Unit::TestCase
  
  def testShouldEncryptWithSingleLowercase
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('a', 3)
      assert_equal 'd', encrypted 
  end
  
  def testShouldEncryptWithSingleUppercase
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('A', 3)
      assert_equal 'D', encrypted 
  end
  
  def testShouldEncryptWithTheEndSingleLowercase
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('z', 3)
      assert_equal 'c', encrypted 
  end
  
  def testShouldEncryptWithTheEndSingleUppercase
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('Z', 3)
      assert_equal 'C', encrypted 
  end
  
end
