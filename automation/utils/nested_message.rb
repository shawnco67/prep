module Automation
  module Utils
    class NestedMessage
      class << self
        def nest
          increment
          yield
          decrement
        end

        def display(message)
          puts "\t" * level + message
        end

        :private
        def decrement
          @level -= 1
        end

        def level
          @level ||= 0
        end

        def increment
          @level ||= 0
          @level += 1
        end
      end
    end
  end
end
