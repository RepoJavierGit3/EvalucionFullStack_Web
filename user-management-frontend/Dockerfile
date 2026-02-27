# Use multi-stage build for Angular frontend
FROM node:20-alpine AS build

WORKDIR /app

# Copy package files
COPY package*.json ./

# Install dependencies including Angular CLI
RUN npm ci

# Copy source code
COPY . .

# Build the Angular application
RUN npx ng build --configuration production

# Use nginx for serving static files
FROM nginx:alpine AS production

# Remove default nginx configuration
RUN rm /etc/nginx/conf.d/default.conf

# Copy built app to nginx
COPY --from=build /app/dist/user-management-frontend/browser /usr/share/nginx/html

# Copy nginx configuration
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
