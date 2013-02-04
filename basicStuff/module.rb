module Debug
  def who_am_i? 
    puts "#{self.class.name} (\##{self.object_id}):#{self.to_s} "
  end
end

class Phonograph
  include Debug
  
  def initialize (message)
    @message = message
  end
  
  def to_s
    @message
  end
end

class EightTrack
  include Debug  
  
  def initialize (message)
    @message = message
  end
  
  def to_s
    @message
  end
end

ph = Phonograph.new("West And Blues")
et = EightTrack.new("Surrealistic Pillow")

ph.who_am_i?
et.who_am_i?