def meet names, &action
    names.each &action
    action.call("you")
end

meet ["Nick", "Carry"] do |name|
  puts "Hello #{name}"
end


array = [1, 2, 3, 4]
  
array.collect! do |n|
  n ** 2
end

puts array.inspect
