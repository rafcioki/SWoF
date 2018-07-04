import * as config from './Config.json'

export function GetRota() {
  return fetch(`${config.apiUrl}`)
    .then(response => {
      if (response.status == 404) {
        return 404
      }

      return response
        .json()
        .then(json => json)
    })
}

export function addNewRota(toDate) {
  return fetch(`${config.apiUrl}?to=${toDate}`, {
    method: 'POST',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json'
    }
  })
}

export function deleteExistingRota() {
  return fetch(`${config.apiUrl}`, {
    method: 'DELETE',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json'
    }
  })
}
