class Array
  def iterate! (&code)
    self.each_with_index do |n, i|
      self[i] = code.call(n)
    end
  end
end

i = 7
a = [1,2,3,4]
a.iterate! do |n|
  n**2 + i
end

puts a
