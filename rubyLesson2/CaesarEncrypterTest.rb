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
  
  def testShouldEncryptWithMultipleLowercases
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('ab', 3)
      assert_equal 'de', encrypted 
  end
  
  def testShouldEncryptWithMultiplUppercases
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('AB', 3)
      assert_equal 'DE', encrypted 
  end
  
  def testShouldEncryptWithMultiplMixedCases
      encrypter = CaesarEncrypter.new()
      encrypted = encrypter.encrypt('xABYbz', 3)
      assert_equal 'aDEBec', encrypted 
  end
  
end
