#!/usr/bin/env ruby

module Automation
  class TimeStamps < Thor
    namespace :timestamps

    desc 'update_all', 'updates all the timestamps'
    def update_all
      timestamps = ::Automation::Utils::TimeStampSet.new(timestamp_file)

      settings.timestamps.bundles.each do |key, value|
        timestamps.add(key, *value[:files])
      end
      timestamps.save
    end

    desc 'update', 'updates a specific timestamp'
    def update(key)
      timestamps = ::Automation::Utils::TimeStampSet.load(timestamp_file)

      timestamps.add(key.to_sym, *settings.timestamps.bundles[key.to_sym][:files])
      timestamps.save
    end

    no_commands do
      def timestamp_file
        settings.timestamps.verification_file
      end
    end
  end
end

