require 'digest'

module Automation
  module Utils
    module FileDigest
      extend self

      def generate(*files)
        digest = ::Digest::SHA256.new

        files.each do |file|
          digest.update File.read(file)
        end

        digest.hexdigest
      end

      def changed?(original, *files)
        original != generate(*files)
      end
    end
  end
end
