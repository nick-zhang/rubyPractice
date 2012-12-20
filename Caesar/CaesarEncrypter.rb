class CaesarEncrypter
  public
  def encrypt text
    result = ''
    text.each_byte do |ascii|
      if (ascii + 3) > 'z'.ord
        result += ((ascii + 3) - 26).chr
      else
        result += (ascii + 3).chr
      end
    end
    result
  end 
end