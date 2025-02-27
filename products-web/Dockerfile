FROM nginx:latest

# Copy Nginx configuration
COPY nginx.conf /etc/nginx/nginx.conf

# Expose port 80 for web traffic
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
