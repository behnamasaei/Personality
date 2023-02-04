import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Personality',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44328/',
    redirectUri: baseUrl,
    clientId: 'Personality_App',
    responseType: 'code',
    scope: 'offline_access Personality',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44328',
      rootNamespace: 'Personality',
    },
  },
} as Environment;
