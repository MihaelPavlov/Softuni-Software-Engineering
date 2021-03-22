import * as api from "./api.js";

const host = "http://localhost:3030";
api.settings.host = host;
export const login = api.login;
export const register = api.register;
export const logout = api.logout;

//implement application - specific request


export async function getTeams() {
  return await api.get(host +'/data/teams');
}
export async function getAllMembers() {
  return await api.get(host +'/data/members?where=status%3D%22member%22');
}

export async function getTeamById(id) {
  return await api.get(host +'/data/teams/'+id);
}