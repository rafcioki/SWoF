import React from 'react';
import moment from 'moment'
import _ from 'lodash'

const Rota = (rota) => {
  const isTodayEntryPredicate = (entry) => moment(entry.dateTime).isSame(new Date(), "day")

  const entries = rota && rota.rota
  const todayEntries = entries && entries.filter(entry => isTodayEntryPredicate(entry))
  const laterEntires = entries && entries.filter(entry => !isTodayEntryPredicate(entry))
  const groupedEntries = laterEntires && _.groupBy(laterEntires, entry => entry.dateTime)

  return (
    <div>
        <div className="support-block">
          <p>Supporting today:</p>
          { 
            todayEntries &&
            todayEntries.map(entry => 
              <div className="today-support-engineer" key={entry.fullName}>{entry.engineer.fullName}</div>
            )
          }
        </div>

        <div>
          { 
            groupedEntries &&
            Object
              .keys(groupedEntries)
              .map(date => {
                return (
                  <div>On {moment(date).format('MMMM Do')}: {
                    groupedEntries[date].reduce((prev, next) => `${prev.engineer.fullName}, ${next.engineer.fullName}`)
                  }</div>
                )
            })
          }
        </div>
    </div>
  )
}

export default Rota