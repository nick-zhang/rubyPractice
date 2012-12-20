class CaesarEncrypter
  public
  def encrypt text
    result = ''
    text.each_byte do |ascii|
      result += (ascii + 3).chr
    end
    result
  end 
end