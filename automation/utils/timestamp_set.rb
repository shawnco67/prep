require 'yaml'

module Automation
  module Utils
    class TimeStampSet
      include ::Automation::Utils::FileDigest

      attr_reader :storage,
        :file

      def initialize(file, data={})
        @storage = data
        @file = file
      end

      def add(key, *files)
        storage[key] = generate(*files)
      end

      def updated?(key, *files)
        return true unless storage.include?(key)

        last_timestamp = storage[key]

        changed?(last_timestamp, *files)
      end

      def save
        IO.write(file, YAML::dump(storage)) 
      end

      def self.load(file)
        data = YAML::load(IO.read(file))
        new(file, data || {}) 
      end
    end
  end
end
