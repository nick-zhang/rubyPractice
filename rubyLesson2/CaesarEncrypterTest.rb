require './CaesarEncrypter'
require 'minitest/autorun'

class CaesarEncrypterTest < MiniTest::Unit::TestCase
  
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
  
  def testShouldEncryptWithTheEndSingleUppercase
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('Z')
      assert_equal 'C', encrypted 
  end
  
  def testShouldEncryptWithMultipleLowercases
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('ab')
      assert_equal 'de', encrypted 
  end
  
  def testShouldEncryptWithMultiplUppercases
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('AB')
      assert_equal 'DE', encrypted 
  end
  
  def testShouldEncryptWithMultiplMixedCases
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('xABYbz')
      assert_equal 'aDEBec', encrypted 
  end
  
end
